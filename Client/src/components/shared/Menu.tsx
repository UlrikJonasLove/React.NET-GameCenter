import { useContext } from "react";
import { Link, NavLink } from "react-router-dom";
import { admin } from "../../constants/GameCenterVariables";
import { AuthContext } from "../../helpers/auth/authContext";
import { logout } from "../../helpers/auth/handleJwt";
import { Authorized } from "../auth/Authorized";
import { Button } from "../utils/Button";

export const Menu = () => {
    // this useContext is used to access the AuthContext
    // and gets the claims and the update function from the context
    const {update, claims} = useContext(AuthContext);

    // this function gets the users email claim 
    const getUserEmail = () : string => {
        return claims.filter(x => x.name === "email")[0]?.value;
    }

    return(
        <nav className="navbar navbar-expand-lg navbar-light bg-light fixed-top">
            <div className="container-fluid">
                <NavLink className="navbar-brand" to="/">Game Center</NavLink>
                <div className="collapse navbar-collapse">
                    <ul className="navbar-nav me-auto mb-2 mb-lg-0" 
                        style={{display: 'flex', justifyContent: 'space-between'}}>

                    <Authorized 
                        role={admin}
                        authorized={<>
                            <li className="nav-item">
                                <NavLink className="nav-link" to="/game/create">
                                    Add Game
                                </NavLink>
                            </li>
                            <li className="nav-item">
                                <NavLink className="nav-link" to="/actors">
                                    Actors
                                </NavLink>
                            </li>
                            <li className="nav-item">
                                <NavLink className="nav-link" to="/genres">
                                    Genres
                                </NavLink>
                            </li>
                            <li className="nav-item">
                                <NavLink className="nav-link" to="/gamecenters">
                                    Game Centers
                                </NavLink>
                            </li>
                        </>} /> 

                        <li className="nav-item">
                            <NavLink className="nav-link" to="/games/search">
                                Search
                            </NavLink>
                        </li>
                        
                    </ul>
                    <div className="d-flex">
                            <Authorized 
                            authorized={<>
                                <span className="nav-link">Hello, {getUserEmail()}</span>
                                <Button 
                                    className="nav-link btn btn-link" 
                                    onClick={() => {
                                        logout();
                                        update([]);
                                    }}>Log out
                                </Button>
                            </>}
                            notAuthorized={<>
                                <Link to="/sign-up" className="nav-link btn-link">Sign up</Link>
                                <Link to="/sign-in" className="nav-link btn-link">Sign in</Link>
                            </>}
                        />
                    </div>
                </div>
            </div>
        </nav>
    )
}