import { AUTH_CONFIG } from "./Constants";
import { UserManager } from "oidc-client";

export const userManager = new UserManager(AUTH_CONFIG);

userManager.events.addAccessTokenExpired(() => {
    console.log('Срок действия токена истек');
    localStorage.setItem('previous-page', window.location.href);
    userManager.signinSilent()
      .then(user => {
        console.log('Пользователь вошел в систему:', user);
        window.location.href =
         localStorage.getItem('previous-page')
          .then(localStorage.removeItem('previous-page'))
      })
      .catch(error => {
        console.error('Ошибка при автоматическом входе:', error);
        window.location.href = '/login';
      });
  });
  userManager.events.addUserLoaded((user) => {
    localStorage.setItem("access_token", user.access_token);
  });