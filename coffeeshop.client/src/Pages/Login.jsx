import { useEffect } from 'react';
import { userManager } from '../utils/authService';
export default function Login() {

  useEffect(() => {
    async function getUser() {
      var user = await userManager.getUser();
      console.log(user);
      if(!user)
      if(!user.expired ) window.location.href = '/';
    }
    getUser();
  }, [])

  function login() {
    userManager.signinRedirect()
  }
  return (
    <div className='align-middle d-flex'>
      <button className='btn btn-info align-middle' onClick={login}>LOGIN</button>
    </div>
  )
}
