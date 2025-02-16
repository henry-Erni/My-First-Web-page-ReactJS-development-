import PropTypes from "prop-types";

const Modal = ({ message, onClose }) => {
    return (
        <div className="fixed inset-0 flex items-center justify-center bg-transparent backdrop-blur-sm backdrop-brightness-75">
            <div className="bg-white p-6 rounded-lg shadow-lg w-80 text-center">
                <p className="text-gray-700 text-lg">{message}</p>
                <button
                    onClick={onClose}
                    className="mt-4 bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-700">
                    OK
                </button>
            </div>
        </div>
    );
};

Modal.propTypes = {
    message: PropTypes.string.isRequired,
    onClose: PropTypes.func.isRequired,
};

export default Modal;
