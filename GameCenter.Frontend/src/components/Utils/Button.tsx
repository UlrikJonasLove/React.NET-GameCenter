import React from "react";

export default function Button(props: buttonProps) {
    return <button 
    className={props.className}
    type={props.type} 
    disabled={props.disabled}
    onClick={props.onClick}
    >{props.children}</button>
}

Button.defaultProps = {
    type: "button",
    disabled: false,
    className: "btn btn-primary"
}
