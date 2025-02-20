

import { useState, useEffect } from "react";
import axios from "axios";
import Modal from "../components/Modal";
import PropTypes from "prop-types";
import { useDispatch } from "react-redux";
import { login } from "../slices/authReducer";
import { useForm } from "react-hook-form";

const AuthForm = ({ title, apiUrl, buttonText, onSuccess }) => {

    const { handleSubmit, register, formState: { errors }, reset, setError, clearErrors } = useForm();
    const dispatch = useDispatch();
    const [showModal, setShowModal] = useState(false);
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        clearErrors();
    }, [title, clearErrors]);
   
    const handleSubmitForm = async (data) => {
        setLoading(true);
        const { username, password } = data;

        try {
            const response = await axios.post(apiUrl, { username, password });
            const responseData = response.data;

            if (title == "Login") {
                dispatch(
                    login({
                        username: responseData.username,
                        userId: responseData.userId,
                        token: responseData.token,
                    })
                );
                onSuccess && onSuccess();
            }

            setShowModal(true);
        } catch (err) {
            if (axios.isAxiosError(err)) {
                if (err.response) {
                    setError("apiError", {
                        message:
                            err.response.data.message ||
                            "An unexpected error occurred.",
                    });
                } else {
                    setError("apiError", {
                        message: "No response from server.",
                    });
                }
            } else {
                setError("apiError", {
                    message: "An unexpected error occurred.",
                });
            }
        } finally {
            setLoading(false);
        }
    };

    const handleCloseModal = () => {
        
        setShowModal(false);
        reset();
    };

    return (
        <div className="sm:border border-gray-300 p-6 rounded-md sm:shadow-md w-96 bg-white">
            <h2 className="text-2xl font-bold mb-4 text-center">{title}</h2>
            <form onSubmit={handleSubmit(handleSubmitForm)}>
                <div className="mb-4">
                    <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="username">
                        Username
                    </label>
                    <input
                        id="username"
                        className={`shadow border rounded w-full py-2 px-3 text-gray-700 ${errors.username ? 'border-red-500' : ''}`}
                        placeholder="Username"
                        {...register('username', { required: "Username is required" })}
                    />
                    {errors.username && <p className="text-red-500">{errors.username.message}</p>}
                </div>
                <div className="mb-6">
                    <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="password">
                        Password
                    </label>
                    <input
                        className={`shadow border rounded w-full py-2 px-3 text-gray-700 ${errors.password ? 'border-red-500' : ''}`}
                        id="password"
                        type="password"
                        placeholder="******************"
                        {...register("password", { required: "Password is required" })}
                    />
                    {errors.password && <p className="text-red-500">{errors.password.message}</p>}
                </div>
                <button 
                    type="submit" 
                    className={`bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 mb-4 px-4 rounded ${loading ? 'opacity-50 cursor-not-allowed' : ''}`} 
                    disabled={loading}
                >
                    {loading ? "Loading..." : buttonText}
                </button>
                {errors.apiError && <p className="text-red-500">{errors.apiError.message}</p>}
            </form>
            {showModal && <Modal message="Successfully registered the user!" onClose={handleCloseModal} />}
        </div>
    );
};

AuthForm.propTypes = {
    title: PropTypes.string.isRequired,
    apiUrl: PropTypes.string.isRequired,
    buttonText: PropTypes.string.isRequired,
    onSuccess: PropTypes.func,
};

export default AuthForm;