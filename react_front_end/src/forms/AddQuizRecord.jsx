import { useForm } from "react-hook-form";
import { useDispatch } from "react-redux";
import { addQuizRecord } from "../slices/quizReducer";


const AddQuizRecord = () => {
    
    const { handleSubmit, register, formState: { errors }, setError, reset} = useForm();
    const dispatch = useDispatch();
    
    const onQuizRecordSubmit = (data) => {
        
        const userId = localStorage.getItem("userId");
        const {title} = data;
        
        const requestData = {
            userId,
            quizRecordName: title
        };
    
        try {
            dispatch(addQuizRecord(requestData));
        } catch (error) {
            setError("title", {
                type: "manual",
                message: error.response ? error.response.data : "Failed to submit quiz record."
            });
        }

        reset();
    }

    return (
            <div className="mt-[20px] bg-gray-200 max-w-md mx-auto p-6 shadow-lg rounded-lg transition-transform transform hover:scale-105">
                <h2 className="text-2xl font-bold text-gray-800 mb-6 text-center">Add Quiz Record</h2>
                <form onSubmit={handleSubmit(onQuizRecordSubmit)}>
                    <div className="mb-6">
                        <input
                            type="text"
                            id="quizTitle"
                            className="bg-white border border-gray-300 rounded-lg p-3 w-full focus:outline-none focus:ring-2 focus:ring-blue-500 transition duration-200"
                            placeholder="Enter quiz title"
                            required
                            {...register("title", {required: "Quiz Record Title is required"})}
                        />
                    </div>
                    {errors.title && (
                        <p className="text-red-500 text-sm mb-4">{errors.title.message}</p>
                    )}
                    <button
                        type="submit"
                        className="bg-blue-600 hover:bg-blue-700 text-white font-semibold py-3 px-4 rounded-lg w-full transition duration-200 transform hover:scale-105"
                    >
                        Add Quiz
                    </button>
                </form>
            </div>
    );
};

export default AddQuizRecord;