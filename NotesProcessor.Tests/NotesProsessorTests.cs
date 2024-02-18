using DAL;
using Models;
using Moq;
using NotesProcessor;
using System.Xml.Linq;

namespace NotesProcessor.Tests
{
    public class NotesProcessorTests
    {

        [Theory]
        [InlineData("test", "ttttt",1)]
        [InlineData("ttt", "teeeest",3)]
        public void GetAllTestCorrectDatae(string name, string val, int prop)
        {
            Mock<INotesAccesser> repositoryMock = new Mock<INotesAccesser>();
            repositoryMock.Setup(x => x.GetAll()).Returns(new List<Note>
                {
                new Note() {Id = Guid.NewGuid(), Name=name, Value=val, Priority=prop },
                new Note() {Id = Guid.NewGuid(), Name=name, Value=val, Priority=prop }
            });
            NotesProcessors processor = new NotesProcessors(repositoryMock.Object);
            IEnumerable<Note> result = processor.GetAll();
            Assert.Equal(2, result.Count());        
        }


        [Fact]
        public void GetAllTestEmptyRepository()
        {
            Mock<INotesAccesser> repositoryMock = new Mock<INotesAccesser>();
            NotesProcessors processor = new NotesProcessors(repositoryMock.Object);
            IEnumerable<Note> result = processor.GetAll();
            Assert.Empty(result);
        }
    }
}