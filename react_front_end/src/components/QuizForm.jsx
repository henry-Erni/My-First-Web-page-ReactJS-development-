import { useState } from "react";

const QuizForm = () => {
  const [question, setQuestion] = useState('');
  const [answer, setAnswer] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    // Handle form submission logic here
    console.log('Question:', question);
    console.log('Answer:', answer);
    // Reset the form fields
    setQuestion('');
    setAnswer('');
  };

  return (
    <div className="flex items-center justify-center min-h-screen bg-gray-100">
      <div className="bg-white shadow-md rounded-lg p-6 w-96">
        <h2 className="text-xl font-semibold text-center mb-4">Quiz Question Form</h2>
        <form onSubmit={handleSubmit}>
          <div className="mb-4">
            <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="question">
              Question
            </label>
            <input
              type="text"
              id="question"
              value={question}
              onChange={(e) => setQuestion(e.target.value)}
              required
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              placeholder="Enter your question"
            />
          </div>
          <div className="mb-4">
            <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="answer">
              Answer
            </label>
            <input
              type="text"
              id="answer"
              value={answer}
              onChange={(e) => setAnswer(e.target.value)}
              required
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              placeholder="Enter the answer"
            />
          </div>
          <div className="flex items-center justify-center">
            <button
              type="submit"
              className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
            >
              Submit
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default QuizForm;