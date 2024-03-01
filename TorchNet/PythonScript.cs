using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythonExecutor
{
    public class PythonScript
    {
        public string pythonScript = @"

import os
import torch
from transformers import GPT2Tokenizer, GPT2LMHeadModel
def create_models_folder():
    # Define the path for the ""models"" folder within the current working directory
    models_path = os.path.join(os.getcwd(), ""models"")
    
    # Check if the ""models"" directory already exists
    if not os.path.exists(models_path):
        # If it does not exist, create it
        os.makedirs(models_path)
        print(f""Created directory at: {models_path}"")
    else:
        print(f""Directory already exists at: {models_path}"")
    
    # Return the path of the ""models"" directory
    return models_path

# Create the models folder and get its path
models_folder_path = create_models_folder()
# Load pre-trained GPT-2 model and tokenizer

        #1: 'gpt2',          # Small
        #2: 'gpt2-medium',   # Medium
        #3: 'gpt2-large',    # Large
        #4: 'gpt2-xl'        # XL
tokenizer = GPT2Tokenizer.from_pretrained('gpt2', cache_dir=models_folder_path)
model = GPT2LMHeadModel.from_pretrained('gpt2', cache_dir=models_folder_path)


# Example function to generate text
def generate_text(prompt, max_length=50):
    # Tokenize input prompt
    input_ids = tokenizer.encode(prompt, return_tensors='pt')

    # Generate text based on prompt
    output = model.generate(input_ids, 
                            max_length=max_length, 
                            num_return_sequences=1,
                            pad_token_id=tokenizer.eos_token_id,
                            attention_mask=torch.ones(input_ids.shape, dtype=torch.long))

    # Decode generated text
    generated_text = tokenizer.decode(output[0], skip_special_tokens=True)

    return generated_text

def chatbot():
    """"""
    Function to simulate chatbot interaction.
    """"""
    print(""Hello! I am a chatbot. How can I assist you today?\nType 'quit' to exit."")
    generate_text(""Assistant : hello User : "")
    while True:
        user_input = input(""You: "")
        
        if user_input.lower() == 'quit':
            print(""Chatbot: Goodbye!"")
            break
        
        # Generate a response from the chatbot
        chatbot_response = generate_text(user_input)
        
        print(f""Chatbot: {chatbot_response}"")

# Example usage
chatbot()
";

    }
}
