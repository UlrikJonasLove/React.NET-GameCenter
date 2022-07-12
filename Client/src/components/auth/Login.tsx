import axios from "axios";
import { useContext, useState } from "react";
import { Link, useHistory } from "react-router-dom";
import { UrlAuth } from "../../constants/endpoints";
import { title } from "../../constants/GameCenterVariables";
import { AuthContext } from "../../helpers/auth/authContext";
import { getClaims, saveToken } from "../../helpers/auth/handleJwt";
import { authCredentials, authResponse } from "../../models/auth/auth.models";
import { DisplayErrors } from "../errorHandling/DisplayErrors";
import { AuthForm } from "./AuthForm";

export const Login = () => {
    document.title = `${title} - Sign In`;
    const history = useHistory();
    const [errors, setErrors] = useState<string[]>([]);
    const {update} = useContext(AuthContext);
  
    const login = async (credentials: authCredentials) => {
      try {
        setErrors([]);
        const response = await axios.post<authResponse>(`${UrlAuth}/login`, credentials);
        saveToken(response.data);
        update(getClaims());
        history.push("/");
      } catch (error) {
        if(error && error.response) {
          setErrors(error.response.data);
        }
      }
    };
  
    return (
      <>
        <h3>Sign in</h3>
        <DisplayErrors errors={errors} />
        <AuthForm
          model={{ email: "", password: "" }}
          onSubmit={async values => await login(values)}
          btnText="Sign in"
        />
        <Link to="/sign-up">no account? Sign up</Link>
      </>
    );
  };