﻿using System;

namespace LL.Graphics3D
{
    public sealed partial class VertexDescriptor
    {
        public VertexDescriptor(
            VertexAttributeDescription[] attributeDescriptions,
            VertexLayoutDescription[] layoutDescriptions)
        {
            for (var i = 0; i < layoutDescriptions.Length; i++)
            {
                // Metal requires a multiple of 4 for the vertex stride.
                if (layoutDescriptions[i].Stride % 4 != 0)
                {
                    throw new ArgumentOutOfRangeException("Stride must be a multiple of 4.");
                }
            }

            PlatformConstruct(attributeDescriptions, layoutDescriptions);
        }
    }

    public struct VertexAttributeDescription
    {
        public InputClassification Classification;
        public string SemanticName;
        public int SemanticIndex;
        public VertexFormat Format;
        public int Offset;
        public int BufferIndex;

        public VertexAttributeDescription(
            InputClassification classification, 
            string semanticName, 
            int semanticIndex,
            VertexFormat format,
            int offset,
            int bufferIndex)
        {
            Classification = classification;
            SemanticName = semanticName;
            SemanticIndex = semanticIndex;
            Format = format;
            Offset = offset;
            BufferIndex = bufferIndex;
        }
    }

    public struct VertexLayoutDescription
    {
        public int Stride;

        public VertexLayoutDescription(int stride)
        {
            Stride = stride;
        }
    }
}