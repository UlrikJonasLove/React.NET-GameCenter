import { ReactElement, useContext, useEffect, useState } from "react";
import { AuthContext } from "../../helpers/auth/authContext";

export const Authorized = (props: authorizedProps) => {
    const [isAuthorized, setIsAuthorized] = useState(true);
    const {claims} = useContext(AuthContext);

    useEffect(() => {
        if(props.role) {
            const index = claims.findIndex(claim => 
                claim.name === props.role && claim.value === props.role);
                // if index is -1, then the claim is not found
                setIsAuthorized(index > -1);
        } else {
            // claims.length > 0 means that the claim is found
            setIsAuthorized(claims.length > 0);
        }
    }, [claims, props.role]);
    return(
        <>
            {isAuthorized ? props.authorized : props.notAuthorized}
        </>
    )
}

interface authorizedProps {
    authorized: ReactElement;
    notAuthorized?: ReactElement;
    role?: string;
}