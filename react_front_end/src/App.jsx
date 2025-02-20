import {  Routes, Route, useNavigate} from "react-router-dom";
import Home from "./pages/Home.jsx";
import AuthPage from "./pages/AuthPage.jsx";
import TestComponent from "./components/TestComponent.jsx";
import ProtectedRoute from "./pages/ProtectedRoute.jsx";
import { useEffect } from "react";
import { useDispatch } from "react-redux";
import { isAuthenticate, logout } from "./slices/authReducer.js";
import AddQuizRecord from "./forms/AddQuizRecord.jsx";
import QuizRecordDashboard from "./components/QuizRecordDashboard.jsx";
import QuizzesList from "./components/QuizzesList.jsx";


const isTokenValid = (token) => {
  if (!token) return false;
  const payload = JSON.parse(atob(token.split('.')[1]));
  return payload.exp > Date.now() / 1000;
};

function App() {
    const dispatch = useDispatch();
    const navigate = useNavigate()

	useEffect(() => {
        const checkAuth = async () => {
            let token = localStorage.getItem('token');
            dispatch(isAuthenticate());
            if (isTokenValid(token)) {
                if (location.pathname === "/") {
                    navigate("home");
                  }
                
            } else {
                dispatch(logout());
                localStorage.removeItem('username')
                localStorage.removeItem('token');
                localStorage.removeItem('userId');
            }
        };

        checkAuth();
    }, [dispatch, navigate]);


	return (
        <Routes>
            <Route path="/" element={<AuthPage />} />
            <Route
                path="home" element={ <ProtectedRoute><Home /></ProtectedRoute>}>
                <Route path="addrecord" element={<AddQuizRecord />} />
                <Route path="quizlist" element={<QuizzesList />} />
            </Route>
            <Route path="recordview" element={<QuizRecordDashboard />} />
            <Route path="test" element={<TestComponent />} />
        </Routes>
    );
}

export default App
