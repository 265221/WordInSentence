using NUnit.Framework;
using Rhino.Mocks;
using System;
using WordsInSentence.Client.InProcAnalyzer;
using WordsInSentence.Contracts;

namespace WordsInSentence.Tests
{
    [TestFixture]
    public class WordProcessorTests
    {
        [Test]
        public void WordProcessor_SomeExtraWordHasArrived_WordIsNotAddedToCache()
        {
            var wordCache = MockRepository.GenerateMock<ICache>();
            bool addToCacheHappened = false;
            wordCache.Expect(x => x.Add(Arg<string>.Is.Anything, Arg<long>.Is.Anything))
                .Do(new Action<string, long>((a, b) => { addToCacheHappened = true; }));
            var testArgs = new WordEventArgs("something", 0, 0);
            var wordProcessor = new WordProcessor(wordCache);
            wordProcessor.ProcessWord(new object(), testArgs);

            Assert.IsFalse(addToCacheHappened);
        }

        [Test]
        public void WordProcessor_WordHasArrived_WordProcessedEventHasBeenThrown()
        {
            var wordCache = MockRepository.GenerateMock<ICache>();
            bool addToCacheHappened = false;
            wordCache.Expect(x => x.Add(Arg<string>.Is.Anything, Arg<long>.Is.Anything))
                .Do(new Action<string, long>((a, b) => { addToCacheHappened = true; }));
            wordCache.Expect(x => x.Keys).Return(new[] { "something interesting" });
            bool wordProcessedEventHasBeenThrown = false;
            var wordProcessedHandler = new EventHandler<WordEventArgs>(new Action<object, WordEventArgs>((a, b) => 
            { wordProcessedEventHasBeenThrown = true; }));
            var lastWordProcessedEventHasBeenThrown = false;
            var lastWordProcessedHandler = new EventHandler(new Action<object, EventArgs>((a, b) =>
            { lastWordProcessedEventHasBeenThrown = true; }));
            var testArgs = new WordEventArgs("something", 0, 2);
            var wordProcessor = new WordProcessor(wordCache);
            wordProcessor.WordProcessed += new EventHandler<WordEventArgs>(wordProcessedHandler);
            wordProcessor.LastWordProcessed += new EventHandler(lastWordProcessedHandler);
            wordProcessor.ProcessWord(new object(), testArgs);

            Assert.IsTrue(addToCacheHappened);
            Assert.IsTrue(wordProcessedEventHasBeenThrown);
            Assert.IsFalse(lastWordProcessedEventHasBeenThrown);
        }

        [Test]
        public void WordProcessor_LastWordHasArrived_LastWordProcessedEventHasBeenThrown()
        {
            var wordCache = MockRepository.GenerateMock<ICache>();
            bool addToCacheHappened = false;
            wordCache.Expect(x => x.Add(Arg<string>.Is.Anything, Arg<long>.Is.Anything))
                .Do(new Action<string, long>((a, b) => { addToCacheHappened = true; }));
            wordCache.Expect(x => x.Keys).Return(new[] { "something interesting" });
            bool wordProcessedEventHasBeenThrown = false;
            var wordProcessedHandler = new EventHandler<WordEventArgs>(new Action<object, WordEventArgs>((a, b) =>
            { wordProcessedEventHasBeenThrown = true; }));
            var lastWordProcessedEventHasBeenThrown = false;
            var lastWordProcessedHandler = new EventHandler(new Action<object, EventArgs>((a, b) =>
            { lastWordProcessedEventHasBeenThrown = true; }));
            var testArgs = new WordEventArgs("something", 0, 1);
            var wordProcessor = new WordProcessor(wordCache);
            wordProcessor.WordProcessed += new EventHandler<WordEventArgs>(wordProcessedHandler);
            wordProcessor.LastWordProcessed += new EventHandler(lastWordProcessedHandler);
            wordProcessor.ProcessWord(new object(), testArgs);

            Assert.IsTrue(addToCacheHappened);
            Assert.IsFalse(wordProcessedEventHasBeenThrown);
            Assert.IsTrue(lastWordProcessedEventHasBeenThrown);
        }


    }
}