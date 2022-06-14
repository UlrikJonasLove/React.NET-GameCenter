export const Loading = (props: loadingProps) => {

    // const gifLoaderStyle={// center the div
    //     position: "absolute",
    //     top: "50%",
    //     left: "50%",
    //     transform: "translate(-50%, -50%)"
    // };

    return(
        <div>
            <p>{props.title}</p>
            <img alt="loading" src="https://i.gifer.com/ZZ5H.gif" width={150} height={155}/>
        </div>
        
    )
}

interface loadingProps {
    title?: string;
}