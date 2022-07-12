import { authResponse, claim } from "../../models/auth/auth.models";


const tokenKey = "token";
const expirationKey = "token-expiration";

export const saveToken = (authData: authResponse) => {
  localStorage.setItem(tokenKey, authData.token);
  localStorage.setItem(expirationKey, authData.expiration.toString());
};

export function getClaims(): claim[] {
  const token = localStorage.getItem(tokenKey);

  // if there is no token, return an empty array
  if (!token) {
    return [];
  }

  const expiration = localStorage.getItem(expirationKey)!;
  const expirationDate = new Date(expiration);

  if (expirationDate <= new Date()) {
    logout();
    return []; // token has expired
  }

  const dataToken = JSON.parse(atob(token.split(".")[1]));
  const response: claim[] = [];

  for (const property in dataToken) {
    response.push({
      name: property,
      value: dataToken[property]
    });
  }

  return response;
}

export const logout = () => {
    localStorage.removeItem(tokenKey);
    localStorage.removeItem(expirationKey);
};

export const getToken = () => {
    return localStorage.getItem(tokenKey);
}