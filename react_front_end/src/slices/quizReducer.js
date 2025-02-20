import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import axios from 'axios';


export const fetchQuizRecords = createAsyncThunk('quiz/fetchQuizRecords', async (userId) => {
    const response = await axios.get("https://localhost:7088/api/QuizRecords", {
        params: { userId }
    });
    console.log(response.data);
    return response.data;
});

export const addQuizRecord = createAsyncThunk('quiz/addQuizRecord', async (requestData) => {
    const response = await axios.post("https://localhost:7088/api/QuizRecords/createrecord", requestData);
    return response.data;
});

export const deleteQuizRecord = createAsyncThunk('quiz/deleteQuizRecord', async (recordId) => {
        const response = await axios.delete("https://localhost:7088/api/QuizRecords",{params: {
            recordId
        }} );
        return response.data;
});

export const addQuiz = createAsyncThunk('quiz/addQuiz', async (requestData) => {
    const response = await axios.post("LOCAL_HOST/api/Quiz/addquiz", requestData);
    return response.data;
});

const quizSlice = createSlice({
    name: 'quiz',
    quiz: null,
    initialState: {
        quizRecords: [],
        status: 'idle'
    },
    reducers: {
    },
    extraReducers: (builder) => {
        builder
            .addCase(fetchQuizRecords.fulfilled, (state, action) => {
                state.quizRecords = action.payload;
            })
            .addCase(addQuizRecord.fulfilled, (state, action) => {
                state.quizRecords.push(action.payload);
            })
            .addCase(deleteQuizRecord.fulfilled, (state, action) => {
                state.quizRecords = state.quizRecords.filter((quiz) => quiz.quizRecordId !== action.payload);
            })
            .addCase(addQuiz.fulfilled, (state, action) => {
                state.quiz = action.payload;
            });
    },
});

export default quizSlice.reducer;