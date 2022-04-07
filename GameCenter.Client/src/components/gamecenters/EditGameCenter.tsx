import GameCenterForm from "./GameCenterForm";

export const EditGameCenter = () => {
    return(
        <>
            <h3>Edit Game Center</h3>
            <GameCenterForm model={{name: "Småland"}} onSubmit={values => console.log(values)}/>
        </>
    )
}