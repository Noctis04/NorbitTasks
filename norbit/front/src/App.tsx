import React from 'react';
import {Routes, Route } from 'react-router-dom';
import HomePage from './components/HomePage';
import UsersPage from './components/UsersPage';
import UserRegPage from './components/UserRegPage';
import UserCart from './components/User/UserCart';
import UserProfile from './components/User/UserProfile';
import BookPage from './components/BookPage';
import CartPage from './components/CartPage';

function App() {

  return (
      <div className="App">
        <Routes>
           <Route path="/" element={<HomePage />} />
            <Route path="/registr" element={<UserRegPage />} />
            <Route path="/users" element={<UsersPage />} />
            <Route path="/profile/:userId" element={<UserProfile />} />
        </Routes>
    </div>
  );
}

export default App;
