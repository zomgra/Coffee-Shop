import React, { useEffect } from 'react'
import { userManager } from '../../utils/authService';

export default function SilentCallback() {

    useEffect(()=>{
        userManager.signinSilentCallback().catch(e=>console.error(e))}
        ,[])

  return (
    <div>
        LOADING;
    </div>
  )
}
