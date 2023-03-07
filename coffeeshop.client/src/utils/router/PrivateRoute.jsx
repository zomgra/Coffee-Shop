import { useEffect, useState } from "react";
import { Outlet, Navigate } from "react-router-dom"
import { userManager } from "../authService";
export default function PrivateRoute() {

  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    async function setAuth() {

      var user = await userManager.getUser();
      const isAuth = user !== null && !user.expired;
      await setIsAuthenticated(isAuth)
      await setIsLoading(false);
    }
    setAuth();
  }, [])

  if (isLoading) {
    return <div>Loading...</div>;
  }
  else {
    return (
      isAuthenticated ? <Outlet /> : <Navigate to="/login" />
    )
  }

}