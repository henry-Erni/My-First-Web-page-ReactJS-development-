import reactLogo from '../assets/react.svg';

const Navigation = () => {
  return (
    <nav className="bg-gray-800 p-4 shadow-lg">
      <div className="container mx-auto flex justify-between items-center">
        <div className="flex items-center">
          <img src={reactLogo} alt="React Logo" className="h-10 mr-3" />
          <span className="text-white text-xl font-semibold">Quiz App</span>
        </div>
        <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">
          Login
        </button>
      </div>
    </nav>
  );
};

export default Navigation;