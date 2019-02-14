using NUnit.Framework;
using Rhino.Mocks;
using System;
using WordInSentence.Contracts;
using WordsInSentence.Client.InProcAnalyzer;

namespace WordsInSentence.Tests
{
    [TestFixture]
    public class SentenceAnalyzerTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCase(@"We expect seven words in this sentence",7)]
        [TestCase(@"Such strange words are also parsed s-s 'use e-e-e -'aer' -'hg-'", 11)]
        [TestCase(@"Underscores are not considered as words s_s", 8)]
        [TestCase(@"Numbers not counted as words 8 88 -11", 8)]
        [TestCase(@"This is a statement, and so is this.", 8)]
        public void SentenceAnalyzer_SentenceIsGiven_CorrectNumberOfWordsIsParsed(string sentence, int wordNumber)
        {
            var wordProcessor = MockRepository.GenerateMock<IWordProcessor>();
            wordProcessor.Expect(r => r.Reset()).Do(new Action(() => { }));
            int wordCounter = 0;
            wordProcessor.Expect(r => r.ProcessWord(Arg<object>.Is.Anything, Arg<WordEventArgs>.Is.Anything)).Do(new Action<object,WordEventArgs>((a,b)=> { ++wordCounter; }));

            var parameters = MockRepository.GenerateMock<IProcessSentenceParameters>();
            parameters.Expect(x => x.Text).Return(sentence);

            var sentenceAnalyzer = new SentenceAnalyzer(wordProcessor);
            sentenceAnalyzer.Initialize();
            sentenceAnalyzer.Analyze(parameters);

            Assert.AreEqual(wordNumber, wordCounter);
        }

        [Test]
        public void SentenceAnalyzer_AnalyzerIsNotInitialized_ExceptionIsThrown()
        {
            var wordProcessor = MockRepository.GenerateMock<IWordProcessor>();
            wordProcessor.Expect(r => r.Reset()).Do(new Action(() => { }));
            int wordCounter = 0;
            wordProcessor.Expect(r => r.ProcessWord(Arg<object>.Is.Anything, Arg<WordEventArgs>.Is.Anything)).Do(new Action<object, WordEventArgs>((a, b) => { ++wordCounter; }));

            var parameters = MockRepository.GenerateMock<IProcessSentenceParameters>();
            parameters.Expect(x => x.Text).Return("heyhey");

            var sentenceAnalyzer = new SentenceAnalyzer(wordProcessor);
            Assert.Throws<NullReferenceException>(()=> sentenceAnalyzer.Analyze(parameters));

        }
    }
}
