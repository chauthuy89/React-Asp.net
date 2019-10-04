import React from "react"
import ReactDOM from "react-dom"



export default class Start extends React.Component {

    render() {
        return (
            <div>
                <h1> Welcome to Onboarding Task</h1>

            </div>
        )
    }
}


ReactDOM.render(<Start />, document.getElementById("root"))