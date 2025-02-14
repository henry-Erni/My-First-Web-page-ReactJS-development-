import { BrowserRouter, Routes, Route} from "react-router-dom";
import QuizPage from "./pages/QuizPage.jsx";
import Login from "./pages/Login.jsx";


function App() {
	return (
		<BrowserRouter>
			<Routes>
				<Route path="/" element={<Login />}/>
				<Route path="quiz" element={<QuizPage />}/>
			</Routes>
		</BrowserRouter>
	)
}

export default App
