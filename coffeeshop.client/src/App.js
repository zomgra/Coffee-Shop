import { useEffect, useState } from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Route, Routes } from 'react-router-dom';
import PrivateRoute from './utils/router/PrivateRoute';
import Login from './Pages/Login';
import Home from './Pages/Home';
import { userManager } from './utils/authService';
import SignInCallback from './Pages/Callbacks/SignInCallback';
import SilentCallback from './Pages/Callbacks/SilentCallback';

function App() {
  const [user, setUser] = useState()

  useEffect(()=>
  {
    async function getUser(){
      setUser(await userManager.getUser())
      console.log(user);
    }
    getUser();
  },[])


  return (
    <div className="App">
      
      <Routes>
        <Route element={<PrivateRoute  />}>
          <Route element={<Home user={user} />} path="/"></Route>
        </Route>
        <Route element={<Login />} path='/login'>
        </Route>
        <Route path="/signin-oidc" element={<SignInCallback />}>
        </Route>
        <Route path="/silent-renew" element={<SilentCallback />}>
        </Route>

      </Routes>


    </div>
  );
}


export default App;
