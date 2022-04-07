import { Redirect } from "react-router-dom";

export const RedirectToLandingPage = () => {
    return <Redirect to={{pathname: "/"}} />
}