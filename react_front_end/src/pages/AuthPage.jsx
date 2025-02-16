import { useState } from "react";
import { useNavigate } from "react-router-dom";
import Navigation from "../components/Navigation";
import AuthForm from "../components/AuthForm";

const AuthPage = () => {
    const [isLogin, setIsLogin] = useState(true);
    const navigate = useNavigate();

    return (
        <div className="min-h-screen flex flex-col">
            <Navigation />
            <h1 className="text-3xl font-bold text-gray-800 text-center py-16">
                Welcome to Mini Quiz App
            </h1>
    
            <div className="flex flex-col items-center justify-center flex-grow p-4 gap-y-6">
                <div className="w-96">
                    <AuthForm
                        title={isLogin ? "Login" : "Sign Up"}
                        apiUrl={
                            isLogin
                                ? "https://localhost:7088/api/Users/login"
                                : "https://localhost:7088/api/Users/register"
                        }
                        buttonText={isLogin ? "Sign In" : "Sign Up"}
                        onSuccess={() => isLogin && navigate("/home")}
                    />
                </div>
    
                <p className="text-center mt-4 text-gray-600">
                    {isLogin ? "Not yet registered?" : "Already have an account?"}{" "}
                    <button
                        onClick={() => setIsLogin(!isLogin)}
                        className="text-blue-500 hover:underline">
                        {isLogin ? "Sign up" : "Login"}
                    </button>
                </p>
            </div>
        </div>
    );
};

export default AuthPage;
