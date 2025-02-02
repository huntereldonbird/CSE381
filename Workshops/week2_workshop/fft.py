# CSE 381 Workshop 2

import matplotlib.pyplot as plt
import numpy as np
import librosa
import math

def FFT(amplitudes):
    """
    Fast Fourier Transform Algorithm
    More Info: https://pythonnumericalmethods.studentorg.berkeley.edu/notebooks/chapter24.03-Fast-Fourier-Transform.html
    Note that this requires amplitudes to have an exact power of 2 length
    """

    n = len(amplitudes)
    if n <= 1:
        return amplitudes

    X_even = FFT(amplitudes[::2])
    X_odd = FFT(amplitudes[1::2])

    # Computing e^(-2*i*pi*k/n) for values k going 0 to N-1
    # In numpy, the j represents the complex number i.
    factors = np.exp(-2j*np.pi*np.arange(n)/ n)
    
    # Combine back X_even and X_odd after applying the factors
    fourier_transform_amplitudes = \
        np.concatenate((X_even+factors[:n//2]*X_odd,
                        X_even+factors[n//2:]*X_odd))
    
    return fourier_transform_amplitudes
    
def gen_sig(signal_rate, freqs, noise=False):
    """
    Generate a combined signal composed of sine waves
    at the specified frequencies.  Noise can be 
    added optionally.
    """
    
    # Create list of signal rate times between 0 and 1.
    ts = 1.0/signal_rate
    time = np.arange(0,1,ts)

    # Initialize amplitudes to 0 before adding different frequencies
    amplitude = np.zeros(signal_rate)

    # Add a sine wave with the specified frequency to the
    # total amplitude
    for freq in freqs:
        amplitude += np.sin(2*np.pi*freq*time)

    if noise:
        # Add random noise using the range of the exisiting amplitudes
        min_value = np.min(amplitude)
        max_value = np.max(amplitude)
        amplitude += np.random.uniform(low=min_value, high=max_value, size=len(time))

    return (time,amplitude)


def load_audio(file):
    """
    Load the amplitudes and signal rate from the audio file.
    """
    
    amplitudes, signal_rate = librosa.load(file)

    # Need to pad it so that the size of amplitudes is a power of 2
    size = len(amplitudes)
    padding = int((2 ** math.ceil(math.log2(size))) - size)
    amplitudes = np.concatenate((amplitudes, np.zeros(padding)))

    return (amplitudes, signal_rate)

    
def plot_signal(time, amplitude):
    """
    Plot Amplitude vs Time
    """
    plt.figure(figsize = (8,6))
    plt.plot(time, amplitude, 'r')
    plt.xlabel("Time")
    plt.ylabel("Amplitude")
    plt.show()

def plot_ft(fourier_transform_amplitudes, signal_rate):
    """
    Plot Frequency vs Fourier Transform Amplitude
    """
    
    # Regenerate the Frequency array
    size = len(fourier_transform_amplitudes)
    freq = np.arange(size) / (size / signal_rate)
    
    plt.figure(figsize = (8,6))
    plt.stem(freq, abs(fourier_transform_amplitudes), 'b')
    plt.xlabel("Freq (Hz)")
    plt.ylabel("FT Amplitude")
    plt.show()


# Add your code here