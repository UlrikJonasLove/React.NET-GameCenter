import { useContext, useEffect, useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import style from './style/utils.module.css';
import Swal from "sweetalert2";
import { AuthContext } from "../../helpers/auth/authContext";

export const Ratings = (props: ratingsProps) => {
    const [maximumValueArr, setMaximumValueArr] = useState<number[]>([]);
    const [selectedValue, setSelectedValue] = useState(props.selectedValue)
    const {claims} = useContext(AuthContext);

    useEffect(() => {
        setMaximumValueArr(Array(props.maximumValue).fill(0));
    }, [props.maximumValue])
    
    const handleMouseOver = (rate: number) => {
        setSelectedValue(rate);
    }

    const handleClick = (rate: number) => {
        const userIsLoggedIn = claims.length > 0;
        if(!userIsLoggedIn) {
            Swal.fire({title: "Error", text: "You need to be logged in to rate a game", icon: "error"});
            return;
        }

        setSelectedValue(rate);
        props.onChange(rate);
    }

    return(
        <>
            {maximumValueArr.map((_, index) => 
                <FontAwesomeIcon
                onMouseOver={() => handleMouseOver(index + 1)}
                onClick={() => handleClick(index+1)}
                icon="star" 
                key={index}
                className={`fa-lg pointer ${selectedValue >= index+1 ? style.checked : null}`} />
            )}
        </>
    )
}

interface ratingsProps {
    maximumValue: number;
    selectedValue: number;
    onChange(rate: number): void;
}