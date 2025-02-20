import PropTypes from "prop-types";
import { useForm, useFieldArray } from "react-hook-form";
import { useDispatch } from "react-redux";
import { addQuiz } from "../slices/quizReducer";

const QuizForm = ({ quiz, onClose }) => {


    const quizName = quiz.quizRecordName;
    const dispatch = useDispatch();

    const {
        register,
        handleSubmit,
        control,
        formState: { errors },
    } = useForm({
        defaultValues: {
            quizRecordId: quiz ? quiz.quizRecordId : "",
            question: quiz ? quiz.question : "",
            options: quiz ? quiz.options : [""],
            correctOption: quiz ? quiz.correctOption : 0,
            points: quiz ? quiz.points : 0,
        },
    });

    const { fields, append, remove } = useFieldArray({
        control,
        name: "options",
    });

    const onFormSubmit = (data) => {
        dispatch(addQuiz(data));
        onClose();
    };

    return (
        <div className="flex items-center justify-center bg-gray-100 p-4 w-full h-full fixed top-0 left-0">
            <div className="bg-white shadow-lg rounded-lg p-6 w-96">
                <h2 className="text-1.5xl font-semibold text-center mb-4 uppercase">
                    {` ADD A QUESTION IN: ${quizName}`}
                </h2>
                <form onSubmit={handleSubmit(onFormSubmit)}>
                    <div className="mb-4">
                        <label
                            className="block text-gray-700 text-sm font-bold mb-2"
                            htmlFor="question"
                        >
                            Question
                        </label>
                        <input
                            type="text"
                            id="question"
                            {...register("question", {
                                required: "Question is required",
                            })}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Enter your question"
                        />
                        {errors.question && (
                            <p className="text-red-500 text-xs italic">
                                {errors.question.message}
                            </p>
                        )}
                    </div>
                    <div className="mb-4">
                        <label
                            className="block text-gray-700 text-sm font-bold mb-2"
                            htmlFor="options"
                        >
                            Options
                        </label>
                        {fields.map((item, index) => (
                            <div key={item.id} className="flex mb-2">
                                <input
                                    type="text"
                                    {...register(`options.${index}`, {
                                        required: true,
                                    })}
                                    className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                                    placeholder={`Option ${index + 1}`}
                                />
                                <button
                                    type="button"
                                    onClick={() => remove(index)}
                                    className="ml-2 text-red-500 hover:text-red-700"
                                >
                                    &times;
                                </button>
                            </div>
                        ))}
                        {fields.length < 4 && (
                            <p className="text-red-500 text-xs italic">
                                At least 4 options are required.
                            </p>
                        )}
                        <button
                            type="button"
                            onClick={() => append("")} // Add a new empty option
                            className="text-blue-500 hover:text-blue-700"
                        >
                            Add Option
                        </button>
                    </div>
                    <div className="mb-4">
                        <label
                            className="block text-gray-700 text-sm font-bold mb-2"
                            htmlFor="correctOption"
                        >
                            Correct Option
                        </label>
                        <input
                            type="number"
                            id="correctOption"
                            {...register("correctOption", {
                                required: "Correct Option is required",
                                min: {
                                    value: 1,
                                    message: "Value must be greater than 1",
                                },
                                max: {
                                    value: fields.length,
                                    message:
                                        "Value cannot exceed the number of options",
                                },
                            })}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        />
                        {errors.correctOption && (
                            <p className="text-red-500 text-xs italic">
                                {errors.correctOption.message}
                            </p>
                        )}
                    </div>
                    <div className="mb-4">
                        <label
                            className="block text-gray-700 text-sm font-bold mb-2"
                            htmlFor="points"
                        >
                            Points
                        </label>
                        <input
                            type="number"
                            id="points"
                            {...register("points", {
                                required: "Points is required",
                                min: {
                                    value: 1,
                                    message: "Points cannot be less than 1",
                                },
                            })}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        />
                        {errors.points && (
                            <p className="text-red-500 text-xs italic">
                                {errors.points.message}
                            </p>
                        )}
                    </div>
                    <div className="flex items-center justify-center">
                        <button
                            type="submit"
                            className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
                        >
                            Submit
                        </button>
                        <button
                            type="button"
                            onClick={onClose}
                            className="ml-2 bg-gray-300 hover:bg-gray-400 text-gray-800 font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
                        >
                            Cancel
                        </button>
                    </div>
                </form>
            </div>
        </div>
    );
};

QuizForm.propTypes = {
    quiz: PropTypes.object,
    onClose: PropTypes.func.isRequired,
};

export default QuizForm;
