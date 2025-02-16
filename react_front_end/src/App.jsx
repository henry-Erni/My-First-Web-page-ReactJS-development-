import { BrowserRouter, Routes, Route} from "react-router-dom";
import Home from "./pages/Home.jsx";
import AuthPage from "./pages/AuthPage.jsx";


function App() {
	return (
		<BrowserRouter>
			<Routes>
				<Route path="/" element={<AuthPage />}/>
				<Route path="home" element={<Home />}/>
			</Routes>
		</BrowserRouter>
	)
}

export default App
