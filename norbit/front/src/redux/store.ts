import {combineReducers, configureStore} from '@reduxjs/toolkit'
import {userAPI} from "./service/userApi";

export const store = configureStore({
    reducer: combineReducers({
        [userAPI.reducerPath]: userAPI.reducer
    }),
    middleware: getDefaultMiddleware => getDefaultMiddleware()
        .concat(userAPI.middleware)
})

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;