import { WebStorageStateStore } from "oidc-client";
import { Auth_Header } from "./authService";

const API_URL = 'https://localhost:7001';
const CURRENT_URL = "http://localhost:3000";
export const CREATE_ORDER_URL = `${API_URL}/api/orders/create`
export const GET_ORDERS_BY_USER_URL = `${API_URL}/api/orders`
export const GET_ORDER_BY_ID_URL = `${API_URL}/api/orders/`
export const CANCEL_ORDER_URL = `${API_URL}/api/orders/cancel`;
export const PAY_ORDER_URL = `${API_URL}/api/orders/pay`;

export const AUTH_CONFIG = {
  authority: 'https://localhost:10001/',
  client_id: 'react-client-id',
  redirect_uri: `${CURRENT_URL}/signin-oidc`,
  post_logout_redirect_uri: `${CURRENT_URL}/login`,
  response_type: 'id_token token',
  scope: 'openid profile CoffeeService offline_access',
  accessTokenExpiringNotificationTime: 300,
  automaticSilentRenew: true,
  silent_redirect_uri: `${CURRENT_URL}/silent-renew`,
  persistAccessToken: true,
  userStore: new WebStorageStateStore({ store: window.localStorage }),
};
