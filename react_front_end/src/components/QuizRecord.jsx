import PropTypes from "prop-types";
import { useDispatch } from "react-redux";
import { deleteQuizRecord, fetchQuizRecords } from "../slices/quizReducer.js";

const QuizRecord = ({ quizRecords, onOpenForm }) => {
    const dispatch = useDispatch();
    const userId = localStorage.getItem("userId");

    const handleDelete = (quiz) => {
        try {
            dispatch(deleteQuizRecord(quiz.quizRecordId));
            dispatch(fetchQuizRecords(userId));
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4 text-center">
            {quizRecords.map((quiz) => (
                <div
                    key={quiz.quizRecordId}
                    className="bg-gray-100 p-4 rounded-lg shadow relative"
                    onClick={() => onOpenForm(quiz)}
                >
                    <h3 className="text-lg font-semibold uppercase">
                        {quiz.quizRecordName}
                    </h3>
                    <button
                        onClick={(e) => {
                            e.stopPropagation();
                            handleDelete(quiz);
                        }}
                        className="absolute top-0 bottom-0 right-2 text-gray-600 hover:text-red-600 text-xl"
                        aria-label="Close"
                    >
                        &times;
                    </button>
                </div>
            ))}
        </div>
    );
};

QuizRecord.propTypes = {
    quizRecords: PropTypes.array.isRequired,
    onOpenForm: PropTypes.func.isRequired
};

export default QuizRecord;
