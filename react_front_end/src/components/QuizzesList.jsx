import { useSelector } from "react-redux";
import { FaClipboardList } from "react-icons/fa"; // Import an icon from react-icons

const QuizzesList = () => {
    const quizRecords = useSelector((state) => state.quiz.quizRecords);
    console.log(quizRecords);

    return (
        <div className="bg-white shadow-lg rounded-lg p-6">
            <h2 className="text-2xl font-bold mb-4 text-gray-800">Quizzes</h2>
            <ul className="space-y-4">
                {quizRecords.length > 0 ? (
                    quizRecords.map((quiz) => (
                        <li
                            key={quiz.quizRecordId}
                            className="bg-gray-100 hover:bg-gray-200 transition duration-200 rounded-lg p-4 flex items-center cursor-pointer transform hover:scale-105"
                        >
                            <FaClipboardList className="text-gray-600 mr-3" />
                            <div>
                                <h3 className="font-semibold text-gray-700">
                                    {quiz.quizRecordName}
                                </h3>
                                <p className="text-gray-500 text-sm">
                                    Questions: {quizRecords.length || 0}
                                </p>
                                {/* Additional info */}
                            </div>
                        </li>
                    ))
                ) : (
                    <p className="text-gray-500">No quizzes available.</p>
                )}
            </ul>
        </div>
    );
};

export default QuizzesList;
