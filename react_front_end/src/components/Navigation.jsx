import { useState } from "react";
import reactLogo from "../assets/react.svg";
import NavButton from "./NavButton";

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
            <NavButton />
        </div>
            {/* Mobile Menu Button */}
            <button className="md:hidden text-white focus:outline-none" onClick={() => setIsOpen(!isOpen)} > ☰ </button>
        </div>

      {isOpen && (
        <div className="md:hidden flex flex-col items-center mt-2">
            <NavButton />
        </div>
      )}
    </nav>
  );
};

export default Navigation;
