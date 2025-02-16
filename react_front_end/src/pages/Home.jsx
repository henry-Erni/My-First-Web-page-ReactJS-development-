import Navigation from "../components/Navigation";
import Button from "../components/Button";

const Home = () => {
  return (
    <>
      <Navigation />
      <div className="flex justify-center items-center min-h-screen bg-gray-100 p-4">
        {/* Responsive Card */}
        <div className="bg-white shadow-lg rounded-2xl p-6 w-full max-w-lg text-center">
          <h1 className="text-2xl font-semibold text-gray-800">Welcome to the Quiz App</h1>
          <p className="text-gray-600 mt-2">Test your knowledge or create new quizzes!</p>

          {/* Buttons */}
          <div className="flex flex-col md:flex-row justify-center gap-4 mt-6">
            <Button className="bg-blue-500 hover:bg-blue-600">Add New Quiz</Button>
            <Button className="bg-green-500 hover:bg-green-600">Answer Existing Quizzes</Button>
          </div>
        </div>
      </div>
    </>
  );
};

export default Home;
