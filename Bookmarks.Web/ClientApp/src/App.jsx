import React from 'react';
import { Route, Routes } from 'react-router';
import Layout from './Layout';
import Home from './Home';
import Signup from './Signup';
import Login from './Login';
import { ContextComponent } from './Context';
import PrivateRoute from './PrivateRoute';
import Logout from './Logout';
import AddBookmark from './AddBookmark';
import MyBookmarks from './MyBookmarks';

const App = () => {
    return (
        <ContextComponent>
            <Layout>
                <Routes>
                    <Route exact path='/' element={<Home />} />
                    <Route exact path='/signup' element={<Signup />} />
                    <Route exact path='/login' element={<Login />} />
                    <Route exact path='/logout' element={
                        <PrivateRoute>
                            <Logout />
                        </PrivateRoute>
                    } />
                    <Route exact path='/mybookmarks' element={
                        <PrivateRoute>
                            <MyBookmarks />
                        </PrivateRoute>
                    } />
                    <Route exact path='/addbookmark' element={
                        <PrivateRoute>
                            <AddBookmark />
                        </PrivateRoute>
                    } />
                </Routes>
            </Layout>
        </ContextComponent>
    );
};

export default App;