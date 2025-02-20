import { configureStore } from '@reduxjs/toolkit';
import authReducer from "./src/slices/authReducer.js";
import quizReducer from "./src/slices/quizReducer.js";

const store = configureStore({
  reducer: {
    auth: authReducer,
    quiz: quizReducer
  },
});

export default store;