import React from "react";

export default function Button(props: buttonProps) {
    return <button className="btn btn-primary" type={props.type} onClick={props.onClick}>{props.children}</button>
}

Button.defaultProps = {
    type: "button"
}
