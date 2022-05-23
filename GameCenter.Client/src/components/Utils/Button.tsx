import React from "react";

export const Button = (props: buttonProps) => {
    return <button 
    className={props.className}
    type={props.type} 
    disabled={props.disabled}
    onClick={props.onClick}
    >{props.children}</button>
}

interface buttonProps{
    children: React.ReactNode;
    onClick?(): void;
    type:"button" | "submit";
    disabled:boolean;
    className: string;
}

Button.defaultProps = {
    type: "button",
    disabled: false,
    className: "btn btn-primary"
}