import { useState, useEffect } from "react";
import QuizRecord from "./QuizRecord";
import { useDispatch, useSelector } from "react-redux";
import { fetchQuizRecords } from "../slices/quizReducer";
import QuizForm from "../forms/QuizForm";

const QuizDashboard = () => {
    const quizRecords = useSelector((state) => state.quiz.quizRecords);
    const dispatch = useDispatch();

    const [isFormVisible, setFormVisible] = useState(false);
    const [selectedQuiz, setSelectedQuiz] = useState(null);

    useEffect(() => {
        const userId = localStorage.getItem("userId");

        const getQuizRecords = async () => {
            try {
                dispatch(fetchQuizRecords(userId));
            } catch (error) {
                console.error(
                    "Error fetching quiz records:",
                    error.response ? error.response.data : error.message
                );
            }
        };

        getQuizRecords();
    }, [dispatch]);

    const handleOpenForm = (quiz) => {
        setSelectedQuiz(quiz); 
        setFormVisible(true);

    };

    const handleCloseForm = () => {
        setFormVisible(false); 
        setSelectedQuiz(null); 
    };

    return (
        <div className="flex w-full h-[calc(100vh-72px)]">
            <div className="bg-white shadow-lg rounded-lg p-6 w-full h-full">
                <h2 className="text-2xl font-bold mb-4 text-center">
                    Quiz Records Dashboard
                </h2>

                {isFormVisible ? (
                    <QuizForm quiz={selectedQuiz} onClose={handleCloseForm} />
                ) : (
                    <QuizRecord quizRecords={quizRecords} onOpenForm={handleOpenForm} />
                )}
            </div>
        </div>
    );
};

export default QuizDashboard;