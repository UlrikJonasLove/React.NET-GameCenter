import GameCenterForm from "./GameCenterForm";

export const CreateGameCenter  = () => {
    return(
        <>
            <h3>Create Game Center</h3>
            <GameCenterForm model={{name: ""}} onSubmit={values => console.log(values)}/>
        </>
    )
}