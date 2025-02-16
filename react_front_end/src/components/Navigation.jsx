import { useState } from "react";
import reactLogo from "../assets/react.svg";

const Navigation = () => {
  const [isOpen, setIsOpen] = useState(false);

  return (
    <nav className="bg-gray-800 p-4 shadow-lg">
      <div className="container mx-auto flex justify-between items-center">
        {/* Logo */}
        <div className="flex items-center">
          <img src={reactLogo} alt="React Logo" className="h-10 mr-3" />
          <span className="text-white text-xl font-semibold">Quiz App</span>
        </div>

        {/* Desktop Menu */}
        <div className="hidden md:flex">
          <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">
            Login
          </button>
        </div>

        {/* Mobile Menu Button */}
        <button
          className="md:hidden text-white focus:outline-none"
          onClick={() => setIsOpen(!isOpen)}
        >
          ☰
        </button>
      </div>

      {/* Mobile Dropdown Menu */}
      {isOpen && (
        <div className="md:hidden flex flex-col items-center mt-2">
          <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded w-full">
            Login
          </button>
        </div>
      )}
    </nav>
  );
};

export default Navigation;
