import { useState } from "react";
import Modal from "./Modal";
import PropTypes from "prop-types";


const AuthForm = ({ title, apiUrl, buttonText, onSuccess }) => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");
    const [showModal, setShowModal] = useState(false);

    const handleSubmit = async (e) => {
        e.preventDefault();
        setError("");

        try {
            const response = await fetch(apiUrl, {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ username, password }),
            });

            if (!response.ok) throw new Error(`${title} failed`);

            const data = await response.json();
            console.log(`${title} successful:`, data);
            onSuccess && onSuccess();
            setShowModal(true);
        } catch (err) {
            setError(err.message);
        }
    };

    const handleCloseModal = () => {
        setShowModal(false);
    };

    return (
        <div className="sm:border border-gray-300 p-6 rounded-md sm:shadow-md w-96 bg-white">
            <h2 className="text-2xl font-bold mb-4 text-center">{title}</h2>
            <form onSubmit={handleSubmit}>
                <div className="mb-4">
                    <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="username">
                        Username
                    </label>
                    <input
                        className="shadow border rounded w-full py-2 px-3 text-gray-700"
                        id="username"
                        type="text"
                        placeholder="Username"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                    />
                </div>
                <div className="mb-6">
                    <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="password">
                        Password
                    </label>
                    <input
                        className="shadow border rounded w-full py-2 px-3 text-gray-700"
                        id="password"
                        type="password"
                        placeholder="******************"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                </div>
                <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">
                    {buttonText}
                </button>
                {error && <p className="text-red-500 mt-2">{error}</p>}
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
