import { useSelector } from 'react-redux';
import PropTypes from 'prop-types';
import { Navigate } from 'react-router-dom';

const ProtectedRoute = ({ children, redirectPath = "/" }) => {

    const isAuthenticated = useSelector((state) => state.auth.isAuthenticated);

    if (!isAuthenticated) {
        return <Navigate to={redirectPath} />;
    }

    return children;
};

ProtectedRoute.propTypes = {
    children: PropTypes.string.isRequired,
    redirectPath: PropTypes.string.isRequired
};

export default ProtectedRoute;