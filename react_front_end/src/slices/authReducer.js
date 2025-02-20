import { createSlice } from '@reduxjs/toolkit';

const initialState = {
    isAuthenticated: false,
    username: null,
    userId: null,
    token: localStorage.getItem('token') || null
}

const authSlice = createSlice({
  name: 'auth',
  initialState,
  reducers: {
    login(state, action) {
      state.isAuthenticated = true;
      state.username = action.payload.username;
      state.token = action.payload.token;
      state.userid = action.payload.userId;
      localStorage.setItem('username', action.payload.username);
      localStorage.setItem('userId', action.payload.userId);
      localStorage.setItem('token', action.payload.token);
    },
    logout(state) {
      state.isAuthenticated = false;
      state.userId = null;
      state.user = null;
      state.token = null;
      localStorage.removeItem('username');
      localStorage.removeItem('userId');
      localStorage.removeItem('token'); 
    },
    isAuthenticate(state) {
      state.isAuthenticated = true;
    }
  },
});

export const { login, logout, isAuthenticate } = authSlice.actions;
export default authSlice.reducer;