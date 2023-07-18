import React, { useEffect } from "react";
import { useParams } from "react-router-dom";
import { useGetUserQuery } from "../../redux/service/userApi";
import { IUser } from "../../types/IUser";

interface UserProfileParams {
  userId: string;
  [key: string]: string | undefined;
}

const UserProfile: React.FC = () => {
  const { userId } = useParams<UserProfileParams>();
  const { data: user, isLoading, isError, error } = useGetUserQuery(Number(userId));

  
  return (
    <div>
      <h1>Профиль пользователя</h1>
      {user && (
        <div>
          <div>
            <strong>Имя:</strong> {user.firstName}
          </div>
          <div>
            <strong>Фамилия:</strong> {user.lastName}
          </div>
          <div>
            <strong>Логин:</strong> {user.login}
          </div>
          <div>
            <strong>Email:</strong> {user.email}
          </div>
          <div>
            <strong>Пароль:</strong> {user.password}
          </div>
        </div>
      )}
    </div>
  );
};


export default UserProfile;
