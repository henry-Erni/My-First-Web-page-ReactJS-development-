import { useState } from "react";
import { useNavigate } from "react-router-dom";

const LoginForm = () => {

    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
	const [error, setError] = useState('');
	const navigate = useNavigate();
   
	const handleSubmit = async (e) => {
        e.preventDefault();
        setError('');

        try {
            const response = await fetch(' https://localhost:7088/api/users/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ username, password }),
            });
			console.log(response);

            if (!response.ok) {
                throw new Error('Login failed');
            }

            const data = await response.json();
            console.log('Login successful:', data);
			navigate("/quiz");
        } catch (err) {
            setError(err.message);
        }
    };
    
    return (
      <div className="flex items-center justify-center min-h-screen">
        <div className="sm:border border-gray-300 p-6 rounded-md sm:shadow-md w-96">
          <h2 className="text-2xl font-bold mb-4">Login</h2>
          <form onSubmit={handleSubmit}>
            <div className="mb-4">
              <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="username">
                Username
              </label>
              <input
                className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                id="username"
                type="text"
                placeholder="Username"
                value={username}
                onChange={e => setUsername(e.target.value)}
              />
            </div>
            <div className="mb-6">
              <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="password">
                Password
              </label>
              <input
                className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 mb-3 leading-tight focus:outline-none focus:shadow-outline"
                id="password"
                type="password"
                placeholder="******************"
				value={password}
				onChange={e => setPassword(e.target.value)}
              />
            </div>
            <div className="flex items-center justify-between">
              <button
                className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
                type="submit"
              >
                Sign In
              </button>
			  {error && <p style={{ color: 'red' }}>{error}</p>}
            </div>
          </form>
        </div>
      </div>
    );
  }
  
  export default LoginForm;