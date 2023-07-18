import React from "react";
import { userAPI } from "../redux/service/userApi";
import UserCard from "./User/UserCart";
import {useNavigate} from "react-router";

const UsersPage = () => {

    const navigate = useNavigate();
    function changeRoute(where: string)
    {
        navigate(where);
    }

    const { data: users } = userAPI.useGetUsersQuery();

    return (
        <div>
            {
                !users || users.length === 0 ? (<h1>Список пользователей пуст.</h1>) :
                    (users.map((user) => <UserCard key={user.id} user={user} />))
            }
        </div>
    );
};

export default UsersPage;