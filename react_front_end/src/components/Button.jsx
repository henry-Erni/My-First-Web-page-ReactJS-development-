import PropTypes from "prop-types";

const Button = ({ children, className, ...props }) => {
  return (
    <button
      className={`px-4 py-2 rounded-lg bg-blue-500 text-white font-semibold hover:bg-blue-600 transition w-full md:w-auto ${className}`}
      {...props}
    >
      {children}
    </button>
  );
};

Button.propTypes = {
  children: PropTypes.node.isRequired,
  className: PropTypes.string,
};

export default Button;
