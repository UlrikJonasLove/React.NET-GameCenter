import axios from "axios";
import { useContext, useState } from "react";
import { AuthContext } from "../../helpers/auth/authContext";
import { authCredentials, authResponse } from "../../models/auth/auth.models";
import { DisplayErrors } from "../errorHandling/DisplayErrors";
import { AuthForm } from "./AuthForm";
import { UrlAuth } from "../../constants/endpoints";
import { Link, useHistory } from "react-router-dom";
import { getClaim, saveToken } from "../../helpers/auth/handleJwt";

export const Register = () => {
    document.title = `Game Center - Sign Up`;

    const history = useHistory();
    const [errors, setErrors] = useState<string[]>([]);
    const {update} = useContext(AuthContext);
      
const register = async (credentials: authCredentials) => {
    try {
        setErrors([]);
        const response = await axios.post<authResponse>(`${UrlAuth}/register`, credentials);
        saveToken(response.data)
        update(getClaim());
        history.push("/");
        console.log(response.data);
    }
    catch(error) {
       setErrors(error.response.data);
    }
}
          
    return (
      <>
        <h3>Sign up</h3>
        <DisplayErrors errors={errors} />
        <AuthForm model={{email: '', password: ''}} 
        onSubmit={async values => await register(values)} btnText="Sign up" />
        <Link to="/sign-in">already have an account? Sign in</Link>
      </>
    );
  };