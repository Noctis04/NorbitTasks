import React from 'react';
import { Link } from "react-router-dom";
import  Button from '@mui/material/Button';
import IconButton from '@mui/material/IconButton';
import AddShoppingCartIcon from '@mui/material/Icon';
 
const HomePage: React.FC = () => {
  return (
    <div>
      <h1>Добро пожаловать на главную страницу!</h1>
      <Button variant="contained" color="primary" component={Link} to="/profile/:userId">
        Перейти к профилю пользователя
      </Button>
      <Button variant="contained" color="primary" component={Link} to="/registr">
        Перейти к регистрации пользователя
      </Button>
      <Button variant="contained" color="primary" component={Link} to="/users">
        Перейти к списку пользователей
      </Button>
      <IconButton color="primary" aria-label="add to shopping cart" > 
        <AddShoppingCartIcon />
      </IconButton>
    </div>
  );
};

export default HomePage;
