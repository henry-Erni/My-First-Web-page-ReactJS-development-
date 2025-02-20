import Navigation from "../components/Navigation";
import { useNavigate } from "react-router-dom";
import Button from "../components/Button";
import { Outlet } from "react-router-dom";
import QuizRecordDashboard from "../components/QuizRecordDashboard";

const Home = () => {
    const navigate = useNavigate();

    const handleAddQuiz = () => {
        navigate("/home/addrecord");
    }

    const handleViewQuiz = () => {
        navigate("/home/quizlist");
    };

    return (
        <>
            <Navigation />
            <div className="flex flex-col md:flex-row min-h-[calc(100vh-72px)] bg-gray-100 p-4">
                <div className="bg-white shadow-lg rounded-2xl p-6 w-full max-w-md md:max-w-lg text-center md:text-left md:mr-4">
                    <div className="text-center pb-4">
                        <h1 className="text-2xl font-semibold text-gray-800">
                            Welcome to the Quiz App
                        </h1>
                        <p className="text-gray-600 mt-2">
                            Test your knowledge or create new quizzes!
                        </p>
                    </div>

                    <div className="flex flex-col justify-center ">
                        <Button className="w-full bg-blue-500 hover:bg-blue-600 mb-2" onClick={handleAddQuiz}>
                            Add New Quiz
                        </Button>
                        <Button className="bg-green-500 hover:bg-green-600 mb-2" onClick={handleViewQuiz}>
                            Answer Existing Quizzes
                        </Button>
                    </div>
                    <Outlet />
                </div>
                <QuizRecordDashboard />
            </div>
        </>
    );
};

export default Home;