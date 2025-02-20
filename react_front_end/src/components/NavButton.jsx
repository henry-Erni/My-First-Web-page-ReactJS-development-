import { useSelector, useDispatch } from "react-redux";
import { logout } from "../slices/authReducer";

const NavButton = () => {
    const { isAuthenticated, username, state } = useSelector((state) => state.auth);
    const user = isAuthenticated ? localStorage.getItem('username') : username;
    const dispatch = useDispatch();

    const handleClick = () => {
        dispatch(logout(state));
    }

    return (
        <div className="flex items-center space-x-4">
            {isAuthenticated ? (
                <>
                    <span className="text-white text-lg font-semibold">
                        Hello, {user}
                    </span>

                    <button onClick={handleClick} className="bg-red-500 hover:bg-red-600 text-white font-semibold py-2 px-4 rounded-lg transition-colors">
                        Logout
                    </button>
                </>
            ) : (
                <button className="bg-blue-500 hover:bg-blue-600 text-white font-semibold py-2 px-4 rounded-lg transition-transform transform hover:scale-105">
                    Login
                </button>
            )}
        </div>
    );
};

export default NavButton;